using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEditor.U2D.Common;
using System;
using UnityEditor.U2D.Sprites;
using UnityEngine.U2D;

#if ENABLE_2D_ANIMATION
using UnityEditor.U2D.Animation;
#endif

namespace UnityEditor.U2D.PSD
{
    internal abstract class PSDDataProvider
    {
        public PSDImporter dataProvider;
    }

    internal class SpriteBoneDataProvider : PSDDataProvider, ISpriteBoneDataProvider
    {
        public List<SpriteBone> GetBones(GUID guid)
        {
            var sprite = ((SpriteMetaData)dataProvider.GetSpriteData(guid));
            Assert.IsNotNull(sprite, string.Format("Sprite not found for GUID:{0}", guid.ToString()));
            return sprite.spriteBone != null ? sprite.spriteBone.ToList() : new List<SpriteBone>();
        }

        public void SetBones(GUID guid, List<SpriteBone> bones)
        {
            var sprite = dataProvider.GetSpriteData(guid);
            if (sprite != null)
                ((SpriteMetaData)sprite).spriteBone = bones;
        }
    }

    internal class TextureDataProvider : PSDDataProvider, ITextureDataProvider
    {
        Texture2D m_ReadableTexture;
        Texture2D m_OriginalTexture;

        PSDImporter textureImporter { get { return (PSDImporter)dataProvider.targetObject; } }

        public Texture2D texture
        {
            get
            {
                if (m_OriginalTexture == null)
                    m_OriginalTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(textureImporter.assetPath);
                return m_OriginalTexture;
            }
        }

        public Texture2D previewTexture
        {
            get { return texture; }
        }

        public Texture2D GetReadableTexture2D()
        {
            if (m_ReadableTexture == null)
            {
                m_ReadableTexture = InternalEditorBridge.CreateTemporaryDuplicate(texture, texture.width, texture.height);
                if (m_ReadableTexture != null)
                    m_ReadableTexture.filterMode = texture.filterMode;
            }
            return m_ReadableTexture;
        }

        public void GetTextureActualWidthAndHeight(out int width, out int height)
        {
            width = dataProvider.textureActualWidth;
            height = dataProvider.textureActualHeight;
        }
    }

    internal class SecondaryTextureDataProvider : PSDDataProvider, ISecondaryTextureDataProvider
    {
        public SecondarySpriteTexture[] textures
        {
            get { return dataProvider.secondaryTextures; }
            set { dataProvider.secondaryTextures = value; }
        }
    }

    internal class SpriteOutlineDataProvider : PSDDataProvider, ISpriteOutlineDataProvider
    {
        public List<Vector2[]> GetOutlines(GUID guid)
        {
            var sprite = ((SpriteMetaData)dataProvider.GetSpriteData(guid));
            Assert.IsNotNull(sprite, string.Format("Sprite not found for GUID:{0}", guid.ToString()));

            var outline = sprite.spriteOutline;
            if (outline != null)
                return outline.Select(x => x.outline).ToList();
            return new List<Vector2[]>();
        }

        public void SetOutlines(GUID guid, List<Vector2[]> data)
        {
            var sprite = dataProvider.GetSpriteData(guid);
            if (sprite != null)
                ((SpriteMetaData)sprite).spriteOutline = data.Select(x => new SpriteOutline() {outline = x}).ToList();
        }

        public float GetTessellationDetail(GUID guid)
        {
            return ((SpriteMetaData)dataProvider.GetSpriteData(guid)).tessellationDetail;
        }

        public void SetTessellationDetail(GUID guid, float value)
        {
            var sprite = dataProvider.GetSpriteData(guid);
            if (sprite != null)
                ((SpriteMetaData)sprite).tessellationDetail = value;
        }
    }

    internal class SpritePhysicsOutlineProvider : PSDDataProvider, ISpritePhysicsOutlineDataProvider
    {
        public List<Vector2[]> GetOutlines(GUID guid)
        {
            var sprite = ((SpriteMetaData)dataProvider.GetSpriteData(guid));
            Assert.IsNotNull(sprite, string.Format("Sprite not found for GUID:{0}", guid.ToString()));
            var outline = sprite.spritePhysicsOutline;
            if (outline != null)
                return outline.Select(x => x.outline).ToList();

            return new List<Vector2[]>();
        }

        public void SetOutlines(GUID guid, List<Vector2[]> data)
        {
            var sprite = dataProvider.GetSpriteData(guid);
            if (sprite != null)
                ((SpriteMetaData)sprite).spritePhysicsOutline = data.Select(x => new SpriteOutline() { outline = x }).ToList();
        }

        public float GetTessellationDetail(GUID guid)
        {
            return ((SpriteMetaData)dataProvider.GetSpriteData(guid)).tessellationDetail;
        }

        public void SetTessellationDetail(GUID guid, float value)
        {
            var sprite = dataProvider.GetSpriteData(guid);
            if (sprite != null)
                ((SpriteMetaData)sprite).tessellationDetail = value;
        }
    }

    internal class SpriteMeshDataProvider : PSDDataProvider, ISpriteMeshDataProvider
    {
        public Vertex2DMetaData[] GetVertices(GUID guid)
        {
            var sprite = ((SpriteMetaData)dataProvider.GetSpriteData(guid));
            Assert.IsNotNull(sprite, string.Format("Sprite not found for GUID:{0}", guid.ToString()));
            var v = sprite.vertices;
            if (v != null)
                return v.ToArray();

            return new Vertex2DMetaData[0];
        }

        public void SetVertices(GUID guid, Vertex2DMetaData[] vertices)
        {
            var sprite = dataProvider.GetSpriteData(guid);
            if (sprite != null)
                ((SpriteMetaData)sprite).vertices = vertices.ToList();
        }

        public int[] GetIndices(GUID guid)
        {
            var sprite = ((SpriteMetaData)dataProvider.GetSpriteData(guid));
            Assert.IsNotNull(sprite, string.Format("Sprite not found for GUID:{0}", guid.ToString()));
            var v = sprite.indices;
            if (v != null)
                return v;

            return new int[0];
        }

        public void SetIndices(GUID guid, int[] indices)
        {
            var sprite = dataProvider.GetSpriteData(guid);
            if (sprite != null)
                ((SpriteMetaData)sprite).indices = indices;
        }

        public Vector2Int[] GetEdges(GUID guid)
        {
            var sprite = ((SpriteMetaData)dataProvider.GetSpriteData(guid));
            Assert.IsNotNull(sprite, string.Format("Sprite not found for GUID:{0}", guid.ToString()));
            var v = sprite.edges;
            if (v != null)
                return v;

            return new Vector2Int[0];
        }

        public void SetEdges(GUID guid, Vector2Int[] edges)
        {
            var sprite = dataProvider.GetSpriteData(guid);
            if (sprite != null)
                ((SpriteMetaData)sprite).edges = edges;
        }
    }
    
#if ENABLE_2D_ANIMATION
    internal class CharacterDataProvider : PSDDataProvider, ICharacterDataProvider
    {
        int ParentGroupInFlatten(Dictionary<int, int> groupDictIndex, List<CharacterGroup> groups, int parentIndex, List<PSDLayer> psdLayers)
        {
            if (parentIndex < 0)
                return -1;
            
            if (groupDictIndex.ContainsKey(parentIndex))
                return groupDictIndex[parentIndex];

            var groupParentIndex = ParentGroupInFlatten(groupDictIndex, groups, psdLayers[parentIndex].parentIndex, psdLayers);
            var newGroup = new CharacterGroup()
            {
                name = psdLayers[parentIndex].name,
                parentGroup = groupParentIndex,
                order = parentIndex
            };

            groups.Add(newGroup);
            groupDictIndex.Add(parentIndex, groups.Count - 1);
            return groups.Count - 1;
        }

        bool GenerateNodeForGroup(int index, List<PSDLayer> psdLayers)
        {
            var layer = psdLayers[index];
            var parentGroup = true;
            if (layer.parentIndex >= 0)
                parentGroup = GenerateNodeForGroup(layer.parentIndex, psdLayers);
            return psdLayers[index].isGroup && !psdLayers[index].flatten && parentGroup;
        }
        
        public CharacterData GetCharacterData()
        {
            var psdLayers = dataProvider.GetPSDLayers();
            var groupDictionaryIndex = new Dictionary<int, int>();
            var groups = new List<CharacterGroup>();
            
            var cd = dataProvider.characterData;
            cd.pivot = dataProvider.GetDocumentPivot();
            var parts = cd.parts == null ? new List<CharacterPart>() : cd.parts.ToList();
            var spriteRects = dataProvider.GetSpriteMetaData();
            parts.RemoveAll(x => Array.FindIndex(spriteRects, y => y.spriteID == new GUID(x.spriteId)) == -1);
            foreach (var spriteMetaData in spriteRects)
            {
                var srIndex = parts.FindIndex(x => new GUID(x.spriteId) == spriteMetaData.spriteID);
                CharacterPart cp = srIndex == -1 ? new CharacterPart() : parts[srIndex];
                cp.spriteId = spriteMetaData.spriteID.ToString();
                cp.order = psdLayers.FindIndex(l => l.spriteID == spriteMetaData.spriteID);
                
                cp.spritePosition = new RectInt();
                
                var spritePos = spriteMetaData.spritePosition;
                cp.spritePosition.position = new Vector2Int((int)spritePos.x, (int)spritePos.y);
                
                cp.spritePosition.size = new Vector2Int((int)spriteMetaData.rect.width, (int)spriteMetaData.rect.height);
                cp.parentGroup = -1;
                //Find group
                var spritePSDLayer = psdLayers.FirstOrDefault(x => x.spriteID == spriteMetaData.spriteID);
                if (spritePSDLayer != null)
                {
                    cp.parentGroup = ParentGroupInFlatten(groupDictionaryIndex, groups, spritePSDLayer.parentIndex, psdLayers);
                }
                
                if (srIndex == -1)
                    parts.Add(cp);
                else
                    parts[srIndex] = cp;
            }
            
            parts.Sort((x, y) =>
            {
                return x.order.CompareTo(y.order);
            });

            parts.Reverse();
            cd.parts = parts.ToArray();
            cd.dimension = dataProvider.canvasSize;
            cd.characterGroups = groups.ToArray();
            return cd;
        }

        public void SetCharacterData(CharacterData characterData)
        {
            characterData.parts = characterData.parts.Reverse().ToArray();
            dataProvider.characterData = characterData;
            dataProvider.SetDocumentPivot(characterData.pivot);
        }
    }

    internal class MainSkeletonDataProvider : PSDDataProvider, IMainSkeletonDataProvider
    {
        public MainSkeletonData GetMainSkeletonData()
        {
            return new MainSkeletonData { bones = dataProvider.mainSkeletonBones };
        }
    }
#endif
}
